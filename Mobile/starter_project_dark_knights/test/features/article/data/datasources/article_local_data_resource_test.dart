import 'dart:convert';

import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/features/article/data/datasources/article_local_data_source.dart';
import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../fixtures/fixture_reader.dart';
import 'article_local_data_resource_test.mocks.dart';

@GenerateMocks([SharedPreferences])
void main() {
  ArticleLocalDataSourceImpl? localDataSourceImpl;
  MockSharedPreferences? mockSharedPreferences;
  setUp(() {
    mockSharedPreferences = MockSharedPreferences();
    localDataSourceImpl =
        ArticleLocalDataSourceImpl(sharedPreferences: mockSharedPreferences!);
  });

  group(
    'getArticles',
    () {
      final List<dynamic> jsonList =
          json.decode(fixture('article_cached.json'));
      final List<ArticleModel> tArticleModels =
          jsonList.map((json) => ArticleModel.fromJson(json)).toList();

      test(
        'should return Articles from shared preferences when there is in the cache',
        () async {
          when(mockSharedPreferences!.getString(any))
              .thenReturn(fixture('article_cached.json'));
          final result = await localDataSourceImpl!.getLastArticles();
          verify(mockSharedPreferences!.getString(CACHED_ARTICLES));
          expect(result, equals(tArticleModels));
        },
      );
      test(
        'Should throuw a CacheException when there is no cached articles',
        () async {
          when(mockSharedPreferences!.getString(any)).thenReturn(null);
          final call = localDataSourceImpl!.getLastArticles;
          expect(() => call(), throwsA(const TypeMatcher<CacheException>()));
        },
      );
    },
  );
  group(
    'cacheArticles',
    () {
      final tArticleModels = [
        ArticleModel(
          id: 'article1',
          title: "Article",
          subtitle: "article",
          description: "description of article",
          postedBy: "user",
          publishedDate: DateTime(2023, 5, 10, 17, 30),
          tag: "art",
          imageUrl: 'https://..',
          likeCount: 2,
          timeEstimate: 2,
        )
      ];
      test(
        'should call SharedPreferences to cache the data',
        () {
          final expectedArticles = jsonEncode(
              tArticleModels.map((article) => article.toJson()).toList());

          when(mockSharedPreferences!.setString(
            CACHED_ARTICLES,
            expectedArticles,
          )).thenAnswer((_) => Future.value(true));
    
          localDataSourceImpl!.cacheArticles(tArticleModels);

          verify(mockSharedPreferences!.setString(
            CACHED_ARTICLES,
            expectedArticles,
          )).called(1);
        },
      );
    },
  );
}
