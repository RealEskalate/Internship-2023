import 'dart:convert';
import 'package:dartsmiths/features/article/data/models/article_model.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import '../../../../fixtures/fixture_readrer.dart';
import 'package:flutter_test/flutter_test.dart';

void main() {
  final tArticleModel = ArticleModel(
      id: "id",
      title: "title",
      subTitle: "subTitle",
      content: "content",
      tags: ["tags1", "tags2"],
      authorId: "authorId");

  final json = {
    "id": "id",
    "title": "title",
    "subTitle": "subTitle",
    "content": "content",
    "tags": ["tags1", "tags2"],
    "authorId": "authorId"
  };

  test('should be subclass of article entity', () async {
    expect(tArticleModel, isA<Article>());
  });

  group("fromJson", () {
    test("should return article model", () {
      // final result = ArticleModel.fromJson(json);
      final Map<String, dynamic> jsonMap = jsonDecode(fixture('article.json'));
      final result = ArticleModel.fromJson(jsonMap);
      expect(tArticleModel, result);
    });
  });

  group('toJson', () {
    test(
      'should return a JSON map containing the proper data',
      () async {
        final result = tArticleModel.toJson();

        expect(json, result);
      },
    );
  });
}
