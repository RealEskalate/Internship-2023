import 'dart:convert';

import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/error/exception.dart';
import 'package:matador/features/login/data/datasources/login_remote_datasource.dart';
import 'package:matador/features/login/data/models/login_model.dart';
import 'package:http/http.dart' as http;
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'login_datasources_test.mocks.dart';

@GenerateMocks([http.Client])
void main() {
  late LoginUserRemoteDataSourceImpl dataSource;
  late MockClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockClient();
    dataSource = LoginUserRemoteDataSourceImpl(client: mockHttpClient);
  });

  final tLoginModel =
      LoginModel(email: 'test@example.com', password: 'password');
  final tUser = {'email': 'test@gmail.com', 'password': 'password'};

  test(
    'should return a LoginModel when the response code is 200',
    () async {
      // arrange
      final expectedResponse = LoginModel.fromJson(tUser);
      final response = http.Response(json.encode(tUser), 200);
      when(mockHttpClient.post(any,
              headers: anyNamed('headers'), body: anyNamed('body')))
          .thenAnswer((_) async => response);
      // act
      final result = await dataSource.authenticate(tLoginModel);
      // assert
      expect(result, equals(expectedResponse));
    },
  );

  test(
    'should throw a ServerException when the response code is not 200',
    () async {
      // arrange
      final response = http.Response('Error', 404);
      when(mockHttpClient.post(any,
              headers: anyNamed('headers'), body: anyNamed('body')))
          .thenAnswer((_) async => response);
      // act
      final call = dataSource.authenticate;
      // assert
      expect(() => call(tLoginModel), throwsA(isInstanceOf<ServerException>()));
    },
  );
}
