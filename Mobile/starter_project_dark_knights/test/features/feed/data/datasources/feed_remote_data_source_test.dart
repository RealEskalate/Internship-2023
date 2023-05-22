import 'dart:convert';

import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/features/feeds/data/datasources/feed_remote_data_source.dart';
import 'package:http/http.dart' as http;

import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import '../../../../fixtures/fixture_reader.dart';
import 'feed_remote_data_source_test.mocks.dart';

@GenerateMocks([http.Client])
void main() {
  late FeedRemoteDataSourceImplementation remoteDataSourceImplementation;
  late MockClient mockClient;

  setUp(() {
    mockClient = MockClient();
    remoteDataSourceImplementation =
        FeedRemoteDataSourceImplementation(client: mockClient);
  });

// get Articles
  group(
    "getArticles",
    () {
      final fixtureData = fixture('article_cached.json');
      final sampleResponse = json.decode(fixtureData);

      final articlesList = List<Map<String, dynamic>>.from(sampleResponse);
      final tArticleModels = articlesList
          .map((jsonInstance) => ArticleModel.fromJson(jsonInstance))
          .toList();
      test(
        "should perform a get request on a URL with application/json header",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final response = await remoteDataSourceImplementation.getArticles();
          expect(response, equals(tArticleModels));

          verify(
            mockClient.get(
              Uri.parse('http://api/article/'),
              headers: {'Content-Type': 'application/json'},
            ),
          );
        },
      );
      test(
        "should return list of ArticleModel when the response code is 200 (success)",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response(fixture('article_cached.json'), 200),
          );

          final result = await remoteDataSourceImplementation.getArticles();
          expect(result, equals(tArticleModels));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response('Something went wrong', 404),
          );

          final call = remoteDataSourceImplementation.getArticles;
          expect(() => call(), throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );
  group(
    "searchArticles",
    () {
      const String query = "tquery";
      final fixtureData = fixture('article_cached.json');
      final sampleResponse = json.decode(fixtureData);

      final articlesList = List<Map<String, dynamic>>.from(sampleResponse);
      final tArticleModels = articlesList
          .map((jsonInstance) => ArticleModel.fromJson(jsonInstance))
          .toList();
      test(
        "should perform a get request on a URL with application/json header",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final response =
              await remoteDataSourceImplementation.searchArticles(query);
          expect(response, equals(tArticleModels));

          verify(
            mockClient.get(
              Uri.parse('http://api/article/search?$query'),
              headers: {'Content-Type': 'application/json'},
            ),
          );
        },
      );
      test(
        "should return list of ArticleModel when the response code is 200 (success)",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response(fixture('article_cached.json'), 200),
          );

          final result =
              await remoteDataSourceImplementation.searchArticles(query);
          expect(result, equals(tArticleModels));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response('Something went wrong', 404),
          );

          final call = remoteDataSourceImplementation.searchArticles;
          expect(
              () => call(query), throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );
  group(
    "filterArticles",
    () {
      const String tag = "tTag";
      final fixtureData = fixture('article_cached.json');
      final sampleResponse = json.decode(fixtureData);

      final articlesList = List<Map<String, dynamic>>.from(sampleResponse);
      final tArticleModels = articlesList
          .map((jsonInstance) => ArticleModel.fromJson(jsonInstance))
          .toList();
      test(
        "should perform a get request on a URL with application/json header",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final response =
              await remoteDataSourceImplementation.filterArticles(tag);
          expect(response, equals(tArticleModels));

          verify(
            mockClient.get(
              Uri.parse('http://api/article/filter?$tag'),
              headers: {'Content-Type': 'application/json'},
            ),
          );
        },
      );
      test(
        "should return list of ArticleModel when the response code is 200 (success)",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response(fixture('article_cached.json'), 200),
          );

          final result =
              await remoteDataSourceImplementation.filterArticles(tag);
          expect(result, equals(tArticleModels));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response('Something went wrong', 404),
          );

          final call = remoteDataSourceImplementation.filterArticles;
          expect(
              () => call(tag), throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );
}
