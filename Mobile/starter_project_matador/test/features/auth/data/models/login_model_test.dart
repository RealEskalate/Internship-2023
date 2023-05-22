import 'package:matador/features/auth/data/models/login_model.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';

@GenerateMocks([LoginModel])
void main() {
  final email = 'test@example.com';
  final password = 'password';
  final id = '12345';
  final loginModel = LoginModel(email: email, password: password, id: id);
  final jsonMap = {'email': email, 'password': password, 'id': id};
  test(
    'should be a subclass of User entity',
    () async {
      expect(loginModel, isA<AuthUser>());
    },
  );
  test('should create a LoginModel object from a JSON map', () {
    final result = LoginModel.fromJson(jsonMap);
    expect(result, loginModel);
  });

  test('should create a JSON map from a LoginModel object', () {
    final result = loginModel.toJson();
    expect(result, jsonMap);
  });
}
