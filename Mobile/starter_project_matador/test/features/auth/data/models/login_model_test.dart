import 'package:matador/features/login/Domain/entities/user.dart';
import 'package:matador/features/login/data/models/login_model.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';

@GenerateMocks([LoginModel])
void main() {
  final loginModel = LoginModel(email: "test@gmail.com", password: "password");
  test(
    'should be a subclass of User entity',
    () async {
      expect(loginModel, isA<User>());
    },
  );
}
