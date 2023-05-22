

import 'dart:convert';

import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/features/Authentication/data/datasources/authenication_remote_data_sources.dart';
import 'package:dark_knights/features/Authentication/data/models/authentication.dart';
import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:http/http.dart' as http;
import 'package:mockito/mockito.dart';

import 'authentication_remote_data_source_test.mocks.dart';
@GenerateMocks([http.Client])

void main() {
  late AuthenticationRemoteDataSourceImpl dataSource;
  late MockClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockClient();
    dataSource = AuthenticationRemoteDataSourceImpl(client: mockHttpClient);
  });


 // group('signup', () {
    
  group('signup', () {
    final newUser = Authentication(
      userName: 'testuser',
      password: 'testpassword',
    );
    final newUserModel = AuthenticationModel(
      userName: 'testuser',
      password: 'testpassword', id: '1',
    );

   test(
      'should perform a POST request on the signup endpoint with the given authentication data',
      () async {
        // Arrange
        final expectedUri = Uri.parse('http://localhost:3000/signup');
        when(mockHttpClient.post(
          expectedUri,
          body: newUser,
          headers: {'Content-Type': 'application/json'},
        )).thenAnswer((_) async =>
            http.Response(json.encode(newUserModel.toJson()), 200));

        // Act
        await dataSource.signup(newUser);

        // Assert
        verify(mockHttpClient.post(
          expectedUri,
          body: newUser,
          headers: {'Content-Type': 'application/json'},
        ));
      },
    );

     test(
      'should return an AuthenticationModel when the signup request is successful',
      () async {
        // arrange
        final expectedUri = Uri.parse('http://localhost:3000/signup');
        when(mockHttpClient.post(
          expectedUri,
          body: anyNamed('body'),
          headers: anyNamed('headers'),
        )).thenAnswer((_) async =>
            http.Response(json.encode(newUserModel.toJson()), 200));

        // act
        final result = await dataSource.signup(newUser);

        // assert
        expect(result, equals(newUserModel));
      },
    );

    test(
      'should throw a ServerException when the signup request is unsuccessful',
      () async {
        // arrange
        final expectedUri = Uri.parse('http://localhost:3000/signup');
        when(mockHttpClient.post(
          expectedUri,
          body: anyNamed('body'),
          headers: anyNamed('headers'),
        )).thenAnswer((_) async => http.Response('Error', 400));

        // act
        final call = dataSource.signup(newUser);

        // assert
        expect(call, throwsA(isInstanceOf<ServerException>()));
      },
    );
  });

  // Add tests for the login method similarly as above
}

