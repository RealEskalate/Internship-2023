import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class AddUser extends UseCase<User, User> {
  final UserRepository? repository;
  AddUser(this.repository);

  @override
  Future<Either<Failure, User>> call(User user) async {
    return await repository!.addUser(user);
  }
}
