import 'package:dartz/dartz.dart';

import 'package:matador/core/error/failures.dart';
import 'package:matador/features/user/domain/entities/user.dart';

abstract class UserRepository {
  Future<Either<Failure, User>> getUserById(int id);
  Future<Either<Failure, User>> updateUserProfile(User user);

}
