import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/feed/home/domain/entity/home.dart';
import 'package:http/http.dart' as http;
import '../../../../../core/error/exception.dart';
import '../model/home.dart';

abstract class HomeRemoteDataSource {
  Future<Home> search(String city);
}

class HomeRemoteDataSourceImpl extends HomeRemoteDataSource {
  final http.Client client;
  HomeRemoteDataSourceImpl({required this.client});

  @override
  Future<Home> search(String city) async {
    const unencodedPath = "/api/v1/test", authority = 'www.myurl.com';
    final queryParameters = {'city': city};
    final uri = _getUri(authority, unencodedPath, queryParameters);
    final response = await _filterFromUrl(uri);
    if (response.statusCode == 200) {
      return HomeModel.fromJson(response.body as Map<String, dynamic>);
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
