import 'package:equatable/equatable.dart';
import 'package:matador/features/login/Domain/repositories/user_repository.dart';

import '../../../../core/failure.dart';
import '../entities/user.dart';
import 'package:dartz/dartz.dart';
import '../../../../core/usecases/usecases.dart';

class GetUser implements UseCase<User, AuthParams> {
  final UserRepository? repository;

  GetUser(this.repository);

  @override
  Future<Either<Failure, User>> call(AuthParams params) async {
    if (params.email.isEmpty) {
      return const Left(InvalidEmailFailure());
    }

    if (params.password.isEmpty) {
      return const Left(InvalidPasswordFailure());
    }

    final result =
        await repository!.authenticate(params.email, params.password);
    return result;
  }
}

class AuthParams extends Equatable {
  final String email;
  final String password;
  const AuthParams({required this.email, required this.password});

  @override
  List<Object?> get props => ([email, password]);
}
