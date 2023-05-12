import 'dart:convert';

import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/features/home/data/model/home.dart';
import 'package:dartsmiths/features/home/domain/entity/home.dart';
import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;

abstract class HomeRemoteDataSource {
  Future<Either<Failure, Home>> search(String term, String tag);
  Future<Either<Failure, Home>> filterByTag(String tag);
}

class HomeRemoteDataSourceImpl extends HomeRemoteDataSource {
  final http.Client client;
  HomeRemoteDataSourceImpl({required this.client});
  @override
  Future<Either<Failure, Home>> filterByTag(String tag) async {
    final queryParameters = {'tag': tag};
    const unencodedPath = "/api/v1/test", authority = 'http://localhost:3000';
    final uri = _getUri(authority, unencodedPath, queryParameters);
    try {
      return Right(await _filterFromUrl(uri));
    } on ServerFailure {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, Home>> search(String term, String tag) async {
    final queryParameters = {'tag': tag, "term": term};
    const unencodedPath = "/api/v1/test", authority = 'www.myurl.com';
    final uri = _getUri(authority, unencodedPath, queryParameters);
    try {
      return Right(await _filterFromUrl(uri));
    } on ServerFailure {
      return Left(ServerFailure());
    }
  }

  Future<Home> _filterFromUrl(Uri uri) async {
    try {
      final response = await client.get(uri, headers: {});
      return HomeModel.fromJson(jsonDecode(response.body));
    } on ServerFailure {
      throw ServerFailure;
    }
  }

  Uri _getUri(String authority, String unencodedPath,
      Map<String, dynamic> queryParameters) {
    final uri = Uri.https(authority, unencodedPath, queryParameters);
    return uri;
  }
}
