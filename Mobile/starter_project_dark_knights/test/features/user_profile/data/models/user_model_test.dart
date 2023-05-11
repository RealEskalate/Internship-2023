import 'dart:convert';

import 'package:dark_knights/features/user_profile/data/models/user_model.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:flutter_test/flutter_test.dart';

import '../../../../fixtures/fixture_reader.dart';

void main() {
  final tUserModel = UserModel(
      id: "1",
      password: "test",
      image: "image",
      username: "username",
      firstName: "firstName",
      lastName: "lastName",
      occupation: "occupation",
      selfDescription: "selfDescription");

  test("Should be a subclass of User Entity", () async {
    expect(tUserModel, isA<UserEntity>());
  });
  test("Should return a valid model when the JSON is valid", () async {
    final Map<String, dynamic> jsonMap = json.decode(fixture("user.json"));

    final result = UserModel.fromJson(jsonMap);
    expect(result, tUserModel);
  });

  test('Should return a JSON map with the proper data', () async {
    final result = tUserModel.toJson();
    final expectedMap = {
      "id": "1",
      "password": "test",
      "image": "image",
      "username": "username",
      "firstName": "firstName",
      "lastName": "lastName",
      "occupation": "occupation",
      "selfDescription": "selfDescription"
    };
    expect(result, expectedMap);
  });
}
