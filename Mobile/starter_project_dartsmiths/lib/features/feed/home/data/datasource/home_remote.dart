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
    // https://www.themoviedb.org/movie/now-playing?api_key=80f12d8d0d2c3bf2fdc8027e32702796
    // https://www.themoviedb.org/search?query=software
    // https://mocki.io/v1/5b69d35d-eacc-490f-8d59-f96f7fcb4628
    final List<dynamic> jsonData = [
      {
        "author": "Sefineh",
        "title": "Education",
        "description": "Software engineer",
        "tag": "Development",
        "imageUrl": "https://fake.png",
        "dateTime": "2023:00:00"
      },
      {
        "author": "Sefineh",
        "title": "Education",
        "description": "Software engineer",
        "tag": "Development",
        "imageUrl": "https://fake.png",
        "dateTime": "2023:00:00"
      },
    ];
    const unencodedPath = "/v1/5b69d35d-eacc-490f-8d59-f96f7fcb4628",
        authority = 'www.mocki.io';
    final uri = _getUri(authority, unencodedPath);
    final response = await _filterFromUrl(uri);
    if (response.statusCode == 200) {
      // final dynamic jsonData = json.decode(response.body);
      // jsonData.map((value) => print(value));
      return jsonData.map<Home>((data) => HomeModel.fromJson(data)).toList();
      // return List<Home>.from(json.decode(response.body).cast<Map<String, dynamic>>())
      //     .map((home) => HomeModel.fromJson(home as Map<String, dynamic>))
      //     .toList();
    }
    throw ServerException();
  }

  Future<http.Response> _filterFromUrl(Uri uri) async {
    return client.get(uri, headers: {});
  }

  Uri _getUri(String authority, String unencodedPath) {
    return Uri.https(authority, unencodedPath);
  }
}
