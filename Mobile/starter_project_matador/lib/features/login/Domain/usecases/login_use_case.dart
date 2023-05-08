import 'package:matador/features/login/Domain/repositories/user_repository.dart';

import '../../../../core/failure.dart';
import '../entities/user.dart';
import 'package:dartz/dartz.dart';

class GetUser {
  final UserRepository? repository;

  GetUser(this.repository);

  Future<Either<Failure, User>> execute(String email, String password) async {
    if (email.isEmpty) {
      return const Left(InvalidEmailFailure());
    }

    if (password.isEmpty) {
      return const Left(InvalidPasswordFailure());
    }

    final result = await repository!.authenticate(email, password);
    return result;
  }
}
