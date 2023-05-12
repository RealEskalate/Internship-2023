import 'dart:convert';

import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:flutter_test/flutter_test.dart';

import '../../../../fixtures/fixture_reader.dart';

void main() {
  final tArticleModel = ArticleModel(
      id: "1",
      title: "Article 1",
      subtitle: "article 1",
      description: "This is article 1",
      postedBy: "user121",
      publishedDate: DateTime(2023, 05, 11, 16, 00),
      tag: "Art",
      imageUrl:
          "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.simplilearn.com%2Fadvantages-and-disadvantages-of-artificial-intelligence-article&psig=AOvVaw16W5CNCoKGx4vcFhNqgLsL&ust=1683894518812000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCNjP7oii7f4CFQAAAAAdAAAAABAE",
      likeCount: 213,
      timeEstimate: 30);

  test('Should be a subclass of Article entity', () async {
    expect(tArticleModel, isA<Article>());
  });

  test("Should return a valid Article model when the json is valid", () async {
    final Map<String, dynamic> jsonMap = json.decode(fixture('article.json'));
    final result = ArticleModel.fromJson(jsonMap);
    expect(result, tArticleModel);
  });

  test("Should return a JSON map contaning the proper data", () async {
    final result = tArticleModel.toJson();
    final expectedResult = {
      "id": "1",
      "title": "Article 1",
      "subtitle": "article 1",
      "description": "This is article 1",
      "postedBy": "user121",
      "publishedDate": "2023-05-11T16:00:00",
      "tag": "Art",
      "imageUrl":
          "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.simplilearn.com%2Fadvantages-and-disadvantages-of-artificial-intelligence-article&psig=AOvVaw16W5CNCoKGx4vcFhNqgLsL&ust=1683894518812000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCNjP7oii7f4CFQAAAAAdAAAAABAE",
      "likeCount": 213,
      "timeEstimate": 30
    };
    expect(result, expectedResult);
  });
}
