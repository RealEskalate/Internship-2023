import 'dart:convert';

import 'package:dartsmiths/features/feed/home/data/model/home.dart';
import 'package:flutter_test/flutter_test.dart';

void main() {
  const homeModel = HomeModel(
    author: 'author',
    title: 'title',
    description: 'description',
    imageUrl: 'imageUrl',
    dateTime: "2023-05-12T12:00:00",
    tag: 'Techs',
  );

  group("Model testing", () {
    test('Model attribute testing', () async {
      expect(homeModel, isA<HomeModel>());
    });
    test('Should return a valid model', () async {
      final Map<String, dynamic> jsonMap =
          jsonDecode(fixture('home_data.json'));

      final result = HomeModel.fromJson(jsonMap);
      expect(result, homeModel);
    });
    test('Should return a JSON map containing the proper data', () async {
      final Map<String, dynamic> jsonMap =
          jsonDecode(fixture('home_data.json'));
      final result = homeModel.toJson();
      expect(jsonMap, equals(result));
    });
  });
}