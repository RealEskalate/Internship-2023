import 'package:flutter_test/flutter_test.dart';
import 'package:matador/features/user/data/models/user_model.dart';
import 'package:matador/features/user/domain/entities/user.dart';

void main() {
  final tUserModel = UserModel(id: "1", userName: "test", email: "test@gmail.com", fullName: "test Test");
  test(
    'should be a subclass of User entity',
        () async {
      // assert
      expect(tUserModel, isA<User>());
    },
  );
}