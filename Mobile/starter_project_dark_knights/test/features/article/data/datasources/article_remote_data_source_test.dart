import 'dart:convert';

import 'package:dark_knights/core/errors/exception.dart';
import 'package:http/http.dart' as http;

import 'package:dark_knights/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import '../../../../fixtures/fixture_reader.dart';
import 'article_remote_data_source_test.mocks.dart';

@GenerateMocks([http.Client])
void main() {
  late ArticleRemoteDataSourceImpl remoteDataSourceImpl;
  late MockClient mockClient;

  setUp(() {
    mockClient = MockClient();
    remoteDataSourceImpl = ArticleRemoteDataSourceImpl(client: mockClient);
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

          final response = await remoteDataSourceImpl.getArticles();
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

          final result = await remoteDataSourceImpl.getArticles();
          expect(result, equals(tArticleModels));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response('Something went wrong', 404),
          );

          final call = remoteDataSourceImpl.getArticles;
          expect(() => call(), throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );

  // Delete Article test
  group(
    "deleteArticle",
    () {
      final fixtureData = fixture('article.json');
      final tArticleModel = ArticleModel.fromJson(json.decode(fixtureData));
      const articleId = '1';
      test(
        "should perform a delete request on a URL",
        () async {
          when(mockClient.delete(any, headers: anyNamed('headers')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final response = await remoteDataSourceImpl.deleteArticle(articleId);
          expect(response, equals(tArticleModel));

          verify(
            mockClient.delete(
              Uri.parse('http://api/article/deleteArticle/1'),
              headers: {'Content-Type': 'application/json'},
            ),
          );
        },
      );
      test(
        "should return the deleted ArticleModel when the response code is 200 (success)",
        () async {
          when(mockClient.delete(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response(fixture('article.json'), 200),
          );

          final result = await remoteDataSourceImpl.deleteArticle(articleId);
          expect(result, equals(tArticleModel));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.delete(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response('Something went wrong', 404),
          );

          final call = remoteDataSourceImpl.deleteArticle;
          expect(() => call(articleId),
              throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );

  // Get Article By Id
  group(
    "getArticleById",
    () {
      final fixtureData = fixture('article.json');
      final sampleResponse = json.decode(fixtureData);

      final article = Map<String, dynamic>.from(sampleResponse);
      final tArticleModel = ArticleModel.fromJson(article);
      const articleId = "1";
      test(
        "should perform a get request on a URL",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final response = await remoteDataSourceImpl.getArticleById(articleId);
          expect(response, equals(tArticleModel));

          verify(
            mockClient.get(
              Uri.parse('http://api/article/$articleId'),
              headers: {'Content-Type': 'application/json'},
            ),
          );
        },
      );
      test(
        "should return ArticleModel when the response code is 200 (success)",
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response(fixture('article.json'), 200),
          );

          final result = await remoteDataSourceImpl.getArticleById(articleId);
          expect(result, equals(tArticleModel));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.get(any, headers: anyNamed('headers'))).thenAnswer(
            (_) async => http.Response('Something went wrong', 404),
          );

          final call = remoteDataSourceImpl.getArticleById;
          expect(() => call(articleId),
              throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );

//   //  Update Article
  group(
    "updateArticle",
    () {
      final fixtureData = fixture('article.json');
      final sampleResponse = json.decode(fixtureData);

      final article = Map<String, dynamic>.from(sampleResponse);
      final tArticleModel = ArticleModel.fromJson(article);
      const articleId = "1";
      test(
        "should perform a put request on a URL",
        () async {
          when(mockClient.put(any,
                  headers: anyNamed('headers'), body: anyNamed('body')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final response = await remoteDataSourceImpl.updateArticle(
              articleId, tArticleModel);
          expect(response, equals(tArticleModel));
          final jsonBody = json.encode(tArticleModel.toJson());
          verify(
            mockClient.put(Uri.parse('http://api/article/updateArticle/1'),
                headers: {'Content-Type': 'application/json'}, body: jsonBody),
          );
        },
      );
      test(
        "should return the updated ArticleModel when the response code is 200 (success)",
        () async {
          when(mockClient.put(any,
                  headers: anyNamed('headers'), body: anyNamed('body')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final result = await remoteDataSourceImpl.updateArticle(
              articleId, tArticleModel);
          expect(result, equals(tArticleModel));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.put(any,
                  headers: anyNamed('headers'), body: anyNamed('body')))
              .thenAnswer(
                  (_) async => http.Response('Something went wrong', 404));

          final call = remoteDataSourceImpl.updateArticle;
          expect(() => call(articleId, tArticleModel),
              throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );

  group(
    "updateArticle",
    () {
      final fixtureData = fixture('article.json');
      final sampleResponse = json.decode(fixtureData);

      final article = Map<String, dynamic>.from(sampleResponse);
      final tArticleModel = ArticleModel.fromJson(article);
      const articleId = "1";
      test(
        "should perform a post request on a URL",
        () async {
          when(mockClient.post(any,
                  headers: anyNamed('headers'), body: anyNamed('body')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final response =
              await remoteDataSourceImpl.postArticle(tArticleModel);

          expect(response, equals(tArticleModel));
          final jsonBody = json.encode(tArticleModel.toJson());
          verify(
            mockClient.post(
              Uri.parse('http://api/article/postArticle'),
              headers: {'Content-Type': 'application/json'},
              body: jsonBody,
            ),
          );
        },
      );
      test(
        "should return the updated ArticleModel when the response code is 200 (success)",
        () async {
          when(mockClient.post(any,
                  headers: anyNamed('headers'), body: anyNamed('body')))
              .thenAnswer((_) async => http.Response(fixtureData, 200));

          final result = await remoteDataSourceImpl.postArticle(tArticleModel);

          expect(result, equals(tArticleModel));
        },
      );
      test(
        'should throw a ServerException when the response code is not 404 or other',
        () async {
          when(mockClient.post(any,
                  headers: anyNamed('headers'), body: anyNamed('body')))
              .thenAnswer(
                  (_) async => http.Response('Something went wrong', 404));

          final call = remoteDataSourceImpl.postArticle;
          expect(() => call(tArticleModel),
              throwsA(const TypeMatcher<ServerException>()));
        },
      );
    },
  );
}
