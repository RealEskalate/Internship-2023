import 'dart:convert';

import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/features/article/domain/usecases/get_article.dart';
import 'package:http/http.dart' as http;
import 'package:meta/meta.dart';
import 'package:dartsmiths/features/article/data/models/article_model.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> postArticle(ArticleModel articleModel);
  Future<ArticleModel> updateArticle(ArticleModel articleModel);
  Future<ArticleModel> GetArticle(String id);
}

class ArticleRemoteDataSourceImpl implements ArticleRemoteDataSource {
  final http.Client client;
  String url = 'http://blogapp.com/article/';
  ArticleRemoteDataSourceImpl({required this.client});

  @override
  Future<ArticleModel> GetArticle(String id) async {
    final response = await client.get(Uri.parse('${url}get_article/$id'),
        headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      return ArticleModel.fromJson(json.decode(response.body));
    } else {
      throw ServerFailure();
    }
  }

  @override
  Future<ArticleModel> postArticle(ArticleModel articleModel) async {
    final response = await client.post(Uri.parse('${url}post_article'),
        body: jsonEncode(articleModel),
        headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      return ArticleModel.fromJson(json.decode(response.body));
    } else {
      throw ServerFailure();
    }
  }

  @override
  Future<ArticleModel> updateArticle(ArticleModel articleModel) async {
    final response = await client.patch(Uri.parse('${url}update_article'),
        body: jsonEncode(articleModel),
        headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      return ArticleModel.fromJson(json.decode(response.body));
    } else {
      throw ServerFailure();
    }
  }
}
