import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/auth/domain/repositories/signup_repository.dart';
import 'package:meta/meta.dart';

import '../entities/user.dart';

class SignUpUser implements UseCase<AuthUser, SignUpParams> {
  final SignUpRepository repository;

  SignUpUser(this.repository);

  @override
  Future<Either<Failure, AuthUser>> call(SignUpParams params) async {
    return await repository.register(params.email, params.password);
  }
}

class SignUpParams extends Equatable {
  final String email;
  final String password;

  SignUpParams({required this.email, required this.password});

  @override
  List<Object> get props => [email, password];
}
