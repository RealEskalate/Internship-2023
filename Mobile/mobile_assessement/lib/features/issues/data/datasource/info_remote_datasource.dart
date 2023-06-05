import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/error/exceptions.dart';
import '../model/info.dart';

abstract class InfoRemoteDataSource {
  Future<InfoDetailModel> GetInfoDetail(String id);
  Future<List<InfoDetailModel>> GetAllInfoDetail();
}

class InfoRemoteDataSourceImpl implements InfoRemoteDataSource {
  final http.Client client;
  // static const String apiKey = "c9b9bbc365e94423b34124714232205";

  InfoRemoteDataSourceImpl({required this.client});

  @override
  Future<InfoDetailModel> GetInfoDetail(String id) async {
    final url = 'http://localhost:3000/api/v1/issue/${id}';
    final response = await client.get(Uri.parse(url));
    if (response.statusCode == 200) {
      final jsonMap = json.decode(response.body);
      return InfoDetailModel.fromJson(jsonMap['data']);
    } else {
      throw ServerException();
    }
  }

  @override
  Future<List<InfoDetailModel>> GetAllInfoDetail() async {
    final url = 'http://localhost:3000/api/v1/issue';
    final response = await client.get(Uri.parse(url));
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final issueList = List<Map<String, dynamic>>.from(jsonResponse);
      final issues =
          issueList.map((json) => InfoDetailModel.fromJson(json)).toList();
      return issues;
    } else {
      throw ServerException();
    }
  }
}
