import 'package:dartsmiths/core/error/failures.dart';
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
    const unencodedPath = "/api/v1/test", authority = 'www.myurl.com';
    final queryParameters = {'tag': tag, "term": term};
    final uri = _getUri(authority, unencodedPath, queryParameters);
    final response = await _filterFromUrl(uri);
    if (response.statusCode == 200) {
      return List<Home>.from(response.body).map((home)=>HomeModel.fromJson(home as Map<String, dynamic>)).toList();
    }
    throw ServerException();
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
