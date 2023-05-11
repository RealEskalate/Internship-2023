import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dartz/dartz.dart';
// import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../repositories/authentication_repository.dart';

// class LoginUseCase implements UseCase<Authentication, Authentication> {
//   final AuthenticationRepository repository;
//   LoginUseCase(this.repository);
//   // @override
//   Future<Either<Failure, Authentication>> call(Authentication payload) async {
//     final user = await repository.signup(payload);
//     return user;
//   }
// }
class SignupUseCase implements UseCase<Authentication, Authentication> {
  final AuthenticationRepository repository;
  SignupUseCase(this.repository);
  @override
  Future<Either<Failure, Authentication>> call(Authentication payload) async {
    return await repository.signup(payload);
  }
}
