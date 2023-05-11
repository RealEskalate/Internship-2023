import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/signup/domain/entities/user.dart';
import 'package:matador/features/signup/domain/repositories/auth_repository.dart';
import 'package:meta/meta.dart';



class SignUpUser implements UseCase<User, SignUpParams> {
  final AuthRepository repository;

  SignUpUser(this.repository);

  @override
  Future<Either<Failure, User>> call(SignUpParams params) async {
    return await repository.signUp(params.email, params.password);
  }
}

class SignUpParams extends Equatable {
  final String email;
  final String password;

  SignUpParams({required this.email, required this.password});

  @override
  List<Object> get props => [email, password];
}
