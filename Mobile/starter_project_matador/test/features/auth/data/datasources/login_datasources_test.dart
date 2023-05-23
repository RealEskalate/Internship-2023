import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/error/exception.dart';
import 'package:matador/features/auth/data/datasources/login_remote_datasource.dart';
import 'package:matador/features/auth/data/models/login_model.dart';

import '../../../user/data/datasources/user_data_source_test.mocks.dart';

@GenerateMocks([http.Client])
void main() {
  MockClient? httpClient;
  LoginRemoteDataSourceImpl? dataSource;

  setUp(() {
    httpClient = MockClient();
    dataSource = LoginRemoteDataSourceImpl(httpClient: httpClient!);
  });

  final email = 'test@example.com';
  final password = 'password';
  final id = '12345';
  final loginModel = LoginModel(email: email, password: password, id: id);
  final responseBody = {'id': id};

  test(
    'should perform a POST request with the correct body and headers',
    () async {
      when(httpClient!.post(any, body: anyNamed('body'))).thenAnswer(
          (_) async => http.Response(json.encode(responseBody), 200));

      await dataSource!.authenticate(email, password);

      verify(httpClient!.post(
        any,
        body: {'email': email, 'password': password},
      ));
    },
  );

  test(
    'should return LoginModel when the response code is 200',
    () async {
      when(httpClient!.post(any, body: anyNamed('body'))).thenAnswer(
          (_) async => http.Response(json.encode(responseBody), 200));

      final result = await dataSource!.authenticate(email, password);

      expect(result, loginModel);
    },
  );

  test(
    'should throw a ServerException when the response code is not 200',
    () async {
      when(httpClient!.post(any, body: anyNamed('body')))
          .thenAnswer((_) async => http.Response('Not Found', 404));

      final call = dataSource!.authenticate;

      expect(() => call(email, password), throwsA(isA<ServerException>()));
    },
  );
}
