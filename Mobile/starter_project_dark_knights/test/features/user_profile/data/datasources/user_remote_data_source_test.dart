import 'dart:convert';

import 'package:dark_knights/features/article/presentation/widgets/add_article_content.dart';

import 'package:dark_knights/features/user_profile/data/datasources/user_remote_data_sources.dart';
import 'package:dark_knights/features/user_profile/data/models/user_model.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:http/http.dart' as http;
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import '../../../../fixtures/fixture_reader.dart';
import 'user_remote_data_source_test.mocks.dart';

void main() {
  late UserRemoteDataSourceImpl datasource;
  late MockClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockClient();
    datasource = UserRemoteDataSourceImpl(client: mockHttpClient);
  });



  group('get Following', () {
    test('should return the following users using the user id', () async {
      const userId = '1';
      final fixtureData = fixture('list_of_users.json');
      final jsonResponse = json.decode(fixtureData);
      final followingList = List<Map<String, dynamic>>.from(jsonResponse);
      final sampledata =
          followingList.map((json) => UserModel.fromJson(json)).toList();

      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response(fixtureData, 200));
      // act
      final result = await datasource.getFollowing(userId);
      // assert
      verify(mockHttpClient.get(
        Uri.parse('https://api/getFollowing/$userId'),
        headers: {'Content-Type': 'application/json'},
      ));
      expect(result, equals(sampledata));
    });




    group('get Number Of Following', () {
      test(''' should return 
      an integer which is the number of ''', () async {
        const userId = "1";
        // Mock the HTTP response from the remote data source
        when(mockHttpClient.get(
                Uri.parse('https://api/getNumberOfFollowing/$userId'),
                headers: {'Content-Type': 'application/json'}))
            .thenAnswer((_) async =>
                http.Response(json.encode({'NumberOfFollowing': 20}), 200));

        final result = await datasource.getNumberOfFollowing(userId);
        verify(mockHttpClient.get(
          Uri.parse('https://api/getNumberOfFollowing/$userId'),
          headers: {'Content-Type': 'application/json'},
        ));
        // Call the function with the mock client and expect it to return the correct number of follow
        expect(result, 20);
      });
    });
  });


  
  group('get Number of followers', () {
    test('return integer which is the number of followers', () async {
      const userId = "1";
      // Mock the HTTP response from the remote data source
      when(mockHttpClient.get(
              Uri.parse('https://api/getNumberOfFollowers/$userId'),
              headers: {'Content-Type': 'application/json'}))
          .thenAnswer((_) async =>
              http.Response(json.encode({'NumberOfFollowers': 20}), 200));

      final result = await datasource.getNumberOfFollowers(userId);
      verify(mockHttpClient.get(
        Uri.parse('https://api/getNumberOfFollowers/$userId'),
        headers: {'Content-Type': 'application/json'},
      ));
      // Call the function with the mock client and expect it to return the correct number of followers
      expect(result, 20);
    });
  });
}
