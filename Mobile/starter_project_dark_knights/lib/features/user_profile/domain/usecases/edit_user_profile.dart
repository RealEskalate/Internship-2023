import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class EditUserProfile implements UseCase<UserEntity, UserEntity> {
  final UserRepository userRepository;

  EditUserProfile(this.userRepository);

  @override
  Future<Either<Failure, UserEntity>> call(UserEntity params) async {
    return await userRepository.editUserProfile(params);
  }
}
