import 'dart:convert';
import 'package:dartsmiths/features/authentication/data/model/user_auth_credentials.dart';
import 'package:dartsmiths/features/authentication/domain/entity/authentication_payload.dart';
import 'package:flutter_test/flutter_test.dart';
import '../../../../core/fixture/user_credential_reader.dart';

void main() {

  const testUserData =
      UserAuthCredentialsModel(username: "test user", password: "test");
  test("UserAuthCredentialModel should be type of UserAuthCredential", () {
    expect(testUserData, isA<UserAuthCredential>());
  });

  test(
      "The static formjson function should return UserAuthCredentialModel instance",
      () {
    final generated = UserAuthCredentialsModel.fromJson(
        json.decode(fixture("user_credential.json")));

    expect(generated, testUserData);
  });

  test("toJson function should reture the instance in json format", () {
    final resultJson = testUserData.toJson();

    expect(resultJson, json.decode(fixture("user_credential.json")) );
  });
  }
