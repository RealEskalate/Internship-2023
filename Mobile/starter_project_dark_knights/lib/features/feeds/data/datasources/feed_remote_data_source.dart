import 'dart:convert';

import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:http/http.dart' as http;

import '../../../../core/errors/exception.dart';

abstract class FeedRemoteDataSource {
  Future<List<ArticleModel>> getArticles();
  Future<List<ArticleModel>> searchArticles(String query);
  Future<List<ArticleModel>> filterArticles(String tag);
}

class FeedRemoteDataSourceImplementation implements FeedRemoteDataSource {
  final http.Client client;
  final uriString = 'http://api/article/';

  FeedRemoteDataSourceImplementation({required this.client});
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
  Future<List<ArticleModel>> filterArticles(String tag) async {
    final response = await client.get(
        Uri.parse(
          '${uriString}filter?$tag',
        ),
        headers: {
          'Content-Type': 'application/json',
        });
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final articlesList = List<Map<String, dynamic>>.from(jsonResponse);
      final articles =
          articlesList.map((json) => ArticleModel.fromJson(json)).toList();
      return articles;
    } else {
      throw ServerException("Internal Server Error");
    }
  }

  @override
  Future<List<ArticleModel>> searchArticles(String query) async {
    final response = await client.get(
        Uri.parse(
          '${uriString}search?$query',
        ),
        headers: {
          'Content-Type': 'application/json',
        });
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final articlesList = List<Map<String, dynamic>>.from(jsonResponse);
      final articles =
          articlesList.map((json) => ArticleModel.fromJson(json)).toList();
      return articles;
    } else {
      throw ServerException("Internal Server Error");
    }
  }
}
