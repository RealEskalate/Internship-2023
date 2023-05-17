import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/errors/exception.dart';
import '../../domain/entities/article.dart';
import '../models/article_model.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> deleteArticle(String id);

  Future<ArticleModel> getArticleById(String id);

  Future<List<ArticleModel>> getArticles();

  Future<List<ArticleModel>> getArticlesByUserId(String userId);

  Future<ArticleModel> postArticle(Article article);

  Future<ArticleModel> updateArticle(String id, Article article);
}

class ArticleRemoteDataSourceImpl implements ArticleRemoteDataSource {
  final http.Client client;
  final uriString = 'http://api/article/';

  ArticleRemoteDataSourceImpl({required this.client});
  @override
  Future<List<ArticleModel>> getArticles() async {
    final response = await client.get(
      Uri.parse(uriString),
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final articlesList = List<Map<String, dynamic>>.from(jsonResponse);
      final articles =
          articlesList.map((json) => ArticleModel.fromJson(json)).toList();
      return articles;
    } else {
      throw ServerException('Internal Server Error');
    }
  }

  @override
  Future<ArticleModel> deleteArticle(String id) async {
    final response = await client.delete(
      Uri.parse('${uriString}deleteArticle/$id'),
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return ArticleModel.fromJson(jsonResponse);
    } else {
      throw ServerException('Internal Server Failure');
    }
  }

  @override
  Future<ArticleModel> getArticleById(String id) async {
    final response = await client.get(
      Uri.parse('$uriString$id'),
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return ArticleModel.fromJson(jsonResponse);
    } else {
      throw ServerException('Internal Server Failure');
    }
  }

  @override
  Future<List<ArticleModel>> getArticlesByUserId(String userId) async {
    final response = await client.get(
      Uri.parse('$uriString$userId'),
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final articles =
          jsonResponse.map((json) => ArticleModel.fromJson(json)).toList();
      return articles;
    } else {
      throw ServerException('Internal Server Failure');
    }
  }

  @override
  Future<ArticleModel> postArticle(Article article) async {
    final articleModel = ArticleModel(
      id: article.id,
      title: article.title,
      subtitle: article.subtitle,
      description: article.description,
      postedBy: article.postedBy,
      publishedDate: article.publishedDate,
      tag: article.tag,
      imageUrl: article.imageUrl,
      likeCount: article.likeCount,
      timeEstimate: article.timeEstimate,
    );

    final jsonBody = json.encode(articleModel.toJson());
    final response = await client.post(
      Uri.parse('${uriString}postArticle'),
      body: jsonBody,
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return ArticleModel.fromJson(jsonResponse);
    } else {
      throw ServerException('Internal Server Failure');
    }
  }

  @override
  Future<ArticleModel> updateArticle(String id, Article article) async {
    final articleModel = ArticleModel(
      id: article.id,
      title: article.title,
      subtitle: article.subtitle,
      description: article.description,
      postedBy: article.postedBy,
      publishedDate: article.publishedDate,
      tag: article.tag,
      imageUrl: article.imageUrl,
      likeCount: article.likeCount,
      timeEstimate: article.timeEstimate,
    );
    final jsonBody = json.encode(articleModel.toJson());
    final response = await client.put(
      Uri.parse('${uriString}updateArticle/$id'),
      body: jsonBody,
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return ArticleModel.fromJson(jsonResponse);
    } else {
      throw ServerException('Internal Server Failure');
    }
  }
}
