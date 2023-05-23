import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:meta/meta.dart';
import 'package:mobile_assessement/features/feed/detail/domain/entity/detail.dart';

import '../../../../../core/error/exception.dart';
import '../model/home_detail.dart';

abstract class HomeDetailRemoteDataSource {

  Future<HomeDetailModel> GetWeather(String city);
}

class HomeRemoteDataSourceImpl implements HomeDetailRemoteDataSource {
  final http.Client client;
  String url = 'http://blogapp.com/article/';
  HomeRemoteDataSourceImpl({required this.client});

  @override
  Future<HomeDetailModel> GetWeather(String city) async {
    final response = await client.get(Uri.parse('${url}get_weather/$city'),
        headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      return HomeDetailModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }

}