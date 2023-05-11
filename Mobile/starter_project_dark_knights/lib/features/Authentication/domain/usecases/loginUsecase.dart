import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures.dart';
import '../entities/authentication_entitiy.dart';
import '../repositories/authentication_repository.dart';



class LoginUseCase implements UseCase<Authentication, Authentication> {
  final AuthenticationRepository repository;
  LoginUseCase(this.repository);
  @override
  Future<Either<Failure, Authentication>> call(Authentication payload) async {
    return await repository.login(payload);
  }
}
