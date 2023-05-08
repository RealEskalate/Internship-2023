import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class GetUserById {
  final UserRepository? repository;
  GetUserById(this.repository);

  Future<Either<Failure, User>> execute({
    required int id,
  }) async {
    return await repository!.getUserById(id);
  }
}



