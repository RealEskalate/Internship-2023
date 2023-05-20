import 'dart:convert';

import 'package:dartsmiths/features/feed/home/domain/entity/home.dart';
import 'package:http/http.dart' as http;
import '../../../../../core/error/exception.dart';
import '../model/home.dart';

abstract class HomeRemoteDataSource {
  Future<List<Home>> search(String term, String tag);
}

class HomeRemoteDataSourceImpl extends HomeRemoteDataSource {
  final http.Client client;
  HomeRemoteDataSourceImpl({required this.client});

  @override
  Future<List<Home>> search(String term, String tag) async {
    const unencodedPath = "/v1/59a357bb-37c3-469e-8de6-63130a8ae6af",
        authority = 'www.mocki.io';
    final queryParameters = {"query": term, "tag": tag};
    final uri = _getUri(authority, unencodedPath, queryParameters);
    final response = await _filterFromUrl(uri);
    if (response.statusCode == 200) {
      List<dynamic> jsonData = json.decode(response.body)['data'];
      return jsonData.map<Home>((data) => HomeModel.fromJson(data)).toList();
    }
    throw ServerException();
  }

  Future<http.Response> _filterFromUrl(Uri uri) async {
    return client.get(uri, headers: {});
  }

  Uri _getUri(String authority, String unencodedPath, Object? queryParameters) {
    return Uri.https(
        authority, unencodedPath, queryParameters as Map<String, dynamic>?);
  }
}
