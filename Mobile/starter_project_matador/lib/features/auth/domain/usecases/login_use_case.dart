import 'package:equatable/equatable.dart';
import 'package:matador/features/auth/domain/repositories/login_repository.dart';

import '../../../../core/error/failures.dart';
import '../entities/user.dart';
import 'package:dartz/dartz.dart';
import '../../../../core/usecases/usecases.dart';

class LoginUserUseCase implements UseCase<AuthUser, AuthParams> {
  final LoginUserRepository? repository;

  LoginUserUseCase(this.repository);

  @override
  Future<Either<Failure, AuthUser>> call(AuthParams params) async {
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
