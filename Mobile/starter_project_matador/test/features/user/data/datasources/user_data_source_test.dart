import 'dart:convert';

import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/error/exceptions.dart';
import 'package:matador/features/user/data/datasources/user_remote_data_source.dart';
import 'package:matador/features/user/data/models/user_model.dart';
import 'package:mockito/annotations.dart';
import 'package:http/http.dart' as http;
import 'package:mockito/mockito.dart';

import 'user_data_source_test.mocks.dart';


@GenerateMocks([http.Client])

void main() {
  late UserRemoteDataSourceImpl dataSource;
  late MockClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockClient();
    dataSource = UserRemoteDataSourceImpl(client: mockHttpClient);
  });

  final tUser = UserModel(
      id: '1',
      userName: 'testuser',
      email: 'testuser@example.com',
      fullName: 'Test User',
      expertise: 'Test Expertise',
      aboutMe: 'Test about me',
      followersCount: 10,
      followingCount: 20,
      profilePicture: 'http://example.com/profile.png');

  final tUserId = '1';

  test(
    'should add a user when the response code is 200',
        () async {
      // arrange
      final expectedResponse = tUser;
      final response = http.Response(json.encode(tUser.toJson()), 200);
      when(mockHttpClient.post(any,
          headers: anyNamed('headers'), body: anyNamed('body')))
          .thenAnswer((_) async => response);
      // act
      final result = await dataSource.addUser(tUser);
      // assert
      expect(result, equals(expectedResponse));
    },
  );

  test(
    'should throw a ServerException when adding a user and the response code is not 200',
        () async {
      // arrange
      final response = http.Response('Error', 404);
      when(mockHttpClient.post(any,
          headers: anyNamed('headers'), body: anyNamed('body')))
          .thenAnswer((_) async => response);
      // act
      final call = dataSource.addUser;
      // assert
      expect(() => call(tUser), throwsA(isInstanceOf<ServerException>()));
    },
  );

  test(
    'should delete a user when the response code is 200',
        () async {
      // arrange
      final response = http.Response('', 200);
      final expectedResponse = null;
      final baseUrl = "http://blogsapi.com/users";

      when(mockHttpClient.delete(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => response);
      // act
      final result = await dataSource.deleteUserById(tUserId);
      // assert
      verify(mockHttpClient.delete(Uri.parse('$baseUrl/$tUserId'), headers: {'Content-Type': 'application/json'}));
    },
  );

  test(
    'should throw a ServerException when deleting a user and the response code is not 200',
        () async {
      // arrange
      final response = http.Response('Error', 404);
      when(mockHttpClient.delete(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => response);
      // act
      final call = dataSource.deleteUserById;
      // assert
      expect(() => call(tUserId), throwsA(isInstanceOf<ServerException>()));
    },
  );

  test(
    'should edit a user when the response code is 200',
        () async {
      // arrange
      final expectedResponse = tUser;
      final response = http.Response(json.encode(tUser.toJson()), 200);
      when(mockHttpClient.put(any,
          headers: anyNamed('headers'), body: anyNamed('body')))
          .thenAnswer((_) async => response);
      // act
      final result = await dataSource.editUserById(tUser);
      // assert
      expect(result, equals(expectedResponse));
    },
  );

  test(
    'should throw a ServerException when editing a user and the response code is not 200',
        () async {
      // arrange
      final response = http.Response('Error', 404);
      when(mockHttpClient.put(any,
          headers: anyNamed('headers'), body: anyNamed('body')))
          .thenAnswer((_) async => response);
      // act
      final call = dataSource.editUserById;
      // assert
      expect(() => call(tUser), throwsA(isInstanceOf<ServerException>()));
    },
  );

  test(
    'should get a user when the response code is 200',
        () async {
      // arrange
      final expectedResponse = tUser;
      final response = http.Response(json.encode(tUser.toJson()), 200);
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => response);
      // act
      final result = await dataSource.getUserById(tUserId);
      // assert
      expect(result, equals(expectedResponse));
    },
  );

  test(
    'should throw a ServerException when getting a user and the response code is not 200',
        () async {
      // arrange
      final response = http.Response('Error', 404);
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => response);
      // act
      final call = dataSource.getUserById;
      // assert
      expect(() => call(tUserId), throwsA(isInstanceOf<ServerException>()));
    },
  );
}