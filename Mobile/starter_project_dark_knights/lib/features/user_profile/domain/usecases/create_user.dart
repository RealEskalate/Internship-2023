import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class CreateUser implements UseCase<UserEntity, UserEntity> {
  final UserRepository userRepository;

  CreateUser(this.userRepository);
  @override
  Future<Either<Failure, UserEntity>> call(UserEntity userEntity) async {
    return await userRepository.createUser(userEntity);
  }
}
