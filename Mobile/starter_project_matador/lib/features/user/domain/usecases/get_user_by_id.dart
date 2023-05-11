import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class GetUserById extends UseCase<User, String> {
  final UserRepository? repository;

  GetUserById(this.repository);

  @override
  Future<Either<Failure, User>> call(String userId) async {
    return await repository!.getUserById(userId);
  }
}

