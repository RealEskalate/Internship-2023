import 'dart:convert';
import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/features/home/domain/entity/home.dart';
import 'package:http/http.dart' as http;

import '../model/home.dart';

abstract class HomeRemoteDataSource {
  Future<Home> search(String term, String tag);
  Future<Home> filterByTag(String tag);
}

class HomeRemoteDataSourceImpl extends HomeRemoteDataSource {
  final http.Client client;
  HomeRemoteDataSourceImpl({required this.client});
  @override
  Future<Home> filterByTag(String tag) async {
    final queryParameters = {'tag': tag};
    const unencodedPath = "/api/v1/test", authority = 'http://localhost:3000';
    final uri = _getUri(authority, unencodedPath, queryParameters);
    final response = await _filterFromUrl(uri);
    if (response.statusCode == 200) {
      return HomeModel.fromJson(jsonDecode(response.body));
    }
    throw ServerFailure();
  }

  @override
  Future<Home> search(String term, String tag) async {
    const unencodedPath = "/api/v1/test", authority = 'www.myurl.com';
    final queryParameters = {'tag': tag, "term": term};
    final uri = _getUri(authority, unencodedPath, queryParameters);
    final response = await _filterFromUrl(uri);
    if (response.statusCode == 200) {
      return HomeModel.fromJson(jsonDecode(response.body));
    }
    throw ServerFailure();
  }

  Future<dynamic> _filterFromUrl(Uri uri) {
    return client.get(uri, headers: {});
  }

  Uri _getUri(String authority, String unencodedPath,
      Map<String, dynamic> queryParameters) {
    final uri = Uri.https(authority, unencodedPath, queryParameters);
    return uri;
  }
}
