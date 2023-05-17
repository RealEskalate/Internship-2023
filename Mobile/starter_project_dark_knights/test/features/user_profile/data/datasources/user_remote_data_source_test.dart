import 'dart:convert';
import 'package:dark_knights/core/errors/exceptions.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_remote_data_source.dart';
import 'package:dark_knights/features/user_profile/data/models/user_model.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:http/http.dart' as http;
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import '../../../../fixtures/fixture_reader.dart';
import 'user_remote_data_source_test.mocks.dart';

@GenerateMocks([http.Client])
void main() {
  late UserRemoteDataSourceImpl datasource;
  late MockClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockClient();
    datasource = UserRemoteDataSourceImpl(client: mockHttpClient);
  });
  

  group("getAllUsers", () {
    test(
      'should preform a GET request on a URL with application/json header',
      () async {
        final fixtureData = fixture('list_of_users.json');
        final sampleResponse = json.decode(fixtureData);
        //arrange
        when(mockHttpClient.get(any, headers: anyNamed('headers')))
            .thenAnswer((_) async => http.Response(fixtureData, 200));
        // act
        await datasource.getAllUsers();

        // Assert
        verify(mockHttpClient.get(
          Uri.parse('https://api/getAllUsers'),
          headers: {'Content-Type': 'application/json'},
        ));
      },
    );
    test(
        'should throw a ServerException if the HTTP call completes with an error status code',
        () {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response('Something went wrong', 404));

      // act
      final call = datasource.getAllUsers;

      // assert
      expect(() => call(), throwsA(TypeMatcher<ServerException>()));
    });
  });

  group("getUserById", () {
    test(
        'should perform a GET request on a URL with application/json header for getUserById',
        () async {
      const userId = '1';
      final fixtureData = fixture('user.json');
      final sampleResponse = UserModel.fromJson(json.decode(fixtureData));
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response(fixtureData, 200));
      // act
      final result = await datasource.getUser(userId);
      // assert
      verify(mockHttpClient.get(
        Uri.parse('https://api/getUser/$userId'),
        headers: {'Content-Type': 'application/json'},
      ));
      expect(result, equals(sampleResponse));
    });
    test(
        'should throw a ServerException if the HTTP call completes with an error status code',
        () {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response('Something went wrong', 404));

      // act
      final call = datasource.getAllUsers;

      // assert
      expect(() => call(), throwsA(TypeMatcher<ServerException>()));
    });
  });
  group("deletUser", () {
    test(
        "should perform Delete request on a URI given User ID with application/json header",
        () async {
      const userId = '1';
      final fixtureData = fixture('user.json');
      final sampleResponse = UserModel.fromJson(json.decode(fixtureData));
      when(mockHttpClient.delete(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response(fixtureData, 200));
      final result = await datasource.deleteUser(userId);
      verify(mockHttpClient.delete(
        Uri.parse('https://api/deleteUser/$userId'),
        headers: {'Content-Type': 'application/json'},
      ));
      expect(result, equals(sampleResponse));
    });
  });
}
