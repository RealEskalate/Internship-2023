import 'dart:convert';
import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import "package:flutter_test/flutter_test.dart";
import 'package:dark_knights/features/Authentication/data/models/authentication.dart';
import 'package:flutter_test/flutter_test.dart';
import '../../../../fixtures/fixure_reader.dart';

void main() {
  final model = AuthenticationModel(
      id: '1', userName: 'testuser', password: 'testpassword');

  group("entityTest", () {
    test("should be subclass of authtnetication_entitiy", () async {
      expect(model, isA<Authentication>());
    });
  });
  group('fromJson', () {
    test(
      'should return a valid model when the JSON contains valid properties',
      () async {
        final Map<String, dynamic> jsonMap =
            json.decode(fixture('authentication_valid.json'));

        final result = AuthenticationModel.fromJson(jsonMap);

        expect(result, model);
      },
    );
  });
  group('toJson', () {
    test('should return a JSON map containing the proper data', () async {
      final expectedMap = {
        'id': '1',
        'userName': 'testuser',
        'password': 'testpassword'
      };
      final result = model.toJson();

      expect(result, expectedMap);
    });
  });
}
