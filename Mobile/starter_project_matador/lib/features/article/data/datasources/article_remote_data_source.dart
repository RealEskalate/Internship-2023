import 'dart:convert';
import 'package:matador/core/error/exception.dart';
import '../models/article_model.dart';
import 'package:http/http.dart' as http;

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> getArticle(String articleId);
  Future<ArticleModel> addArticle(ArticleModel article);
  Future<ArticleModel> editArticleById(ArticleModel article);
  Future<void> deleteArticleById(String articleId);
}

class ArticleRemoteDataSourceImpl implements ArticleRemoteDataSource {
  final http.Client client;
  ArticleRemoteDataSourceImpl(this.client);

  @override
  Future<ArticleModel> getArticle(String articleId) async {
    final url = Uri.parse("http://blogspapi/articles/$articleId");
    final response =
        await client.get(url, headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      return ArticleModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }

  @override
  Future<ArticleModel> addArticle(ArticleModel article) async {
    final url = Uri.parse("http://blogsapi.com/articles/${article.id}");

    final response = await client.post(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode(article.toJson()),
    );
    if (response.statusCode == 200) {
      return ArticleModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }

  @override
  Future<void> deleteArticleById(String id) async {
    final url = Uri.parse("http://blogsapi.com/users/$id");
    final response = await client.delete(
      url,
      headers: {'Content-Type': 'application/json'},
    );
    if (response.statusCode != 200) {
      throw ServerException();
    }
  }

  @override
  Future<ArticleModel> editArticleById(ArticleModel article) async {
    final url = Uri.parse("http://blogsapi.com/users/${article.id}");

    final response = await client.put(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode(article.toJson()),
    );

    if (response.statusCode == 200) {
      return ArticleModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }
}
