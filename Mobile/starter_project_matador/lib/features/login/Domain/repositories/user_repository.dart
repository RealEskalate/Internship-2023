import 'package:dartz/dartz.dart';

import '../../../../core/failure.dart';
import '../entities/user.dart';

abstract class UserRepository {
  Future<Either<Failure, User>> authenticate(String email, String password);
  // Future<void> logOut();
  // Future<bool> isSignedIn();
  // Future<void> updateUser(User user);
}
