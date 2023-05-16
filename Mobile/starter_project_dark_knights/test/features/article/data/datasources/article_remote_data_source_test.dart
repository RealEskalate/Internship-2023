import 'dart:convert';

import 'package:dark_knights/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:http/http.dart' as http;

import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import '../../../../fixtures/fixture_reader.dart';
import 'article_remote_data_source_test.mocks.dart';

@GenerateMocks([http.Client])
void main() {
  late ArticleRemoteDataSourceImpl remoteDataSourceImpl;
  late MockClient mockClient;

  setUp(() {
    mockClient = MockClient();
    remoteDataSourceImpl = ArticleRemoteDataSourceImpl(client: mockClient);
  });

  test("should perform a get request on a URL with application/json header",
      () async {
    final fixtureData = fixture('article_cached.json');
    final sampleResponse = json.decode(fixtureData);
    final articleList = List<Map<String, dynamic>>.from(sampleResponse);
    final articles = articleList
        .map((jsonInstance) => ArticleModel.fromJson(jsonInstance))
        .toList();

    when(mockClient.get(any, headers: anyNamed('headers')))
        .thenAnswer((_) async => http.Response(fixtureData, 200));

    final response = await remoteDataSourceImpl.getArticles();
    verify(mockClient.get(
      Uri.parse('http://localhost:3000/'),
      headers: {'Content-Type': 'application/json'},
    ));
    expect(response, equals(articles));
  });
}
