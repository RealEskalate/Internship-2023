import 'dart:convert';

import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

abstract class ArticleLocalDataSource {
  Future<List<ArticleModel>> getLastArticles();
  Future<void> cacheArticles(List<ArticleModel> articles);
}

const CACHED_ARTICLES = 'CACHED_ARTICLES';

class ArticleLocalDataSourceImpl implements ArticleLocalDataSource {
  final SharedPreferences sharedPreferences;
  ArticleLocalDataSourceImpl({required this.sharedPreferences});
  @override
  Future<List<ArticleModel>> getLastArticles() {
    final jsonString = sharedPreferences.getString(CACHED_ARTICLES);

    if (jsonString != null) {
      final List<dynamic> jsonData = json.decode(jsonString);
      final List<ArticleModel> articles =
          jsonData.map((json) => ArticleModel.fromJson(json)).toList();
      return Future.value(articles);
    } else {
      throw CacheException('Local Cache Failure');
    }
  }

  @override
  Future<void> cacheArticles(List<ArticleModel> articles) {
    final encodedArticles =
        jsonEncode(articles.map((article) => article.toJson()).toList());
    return sharedPreferences.setString(CACHED_ARTICLES, encodedArticles);
  }
}
