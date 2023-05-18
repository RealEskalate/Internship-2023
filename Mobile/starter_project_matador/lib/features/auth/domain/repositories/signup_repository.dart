import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';

import '../entities/user.dart';

abstract class SignUpRepository {
  Future<Either<Failure, AuthUser>> register(String email, String password);
}
