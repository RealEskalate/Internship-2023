import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../entities/user.dart';

abstract class LoginUserRepository {
  Future<Either<Failure, AuthUser>> authenticate(String email, String password);
}
