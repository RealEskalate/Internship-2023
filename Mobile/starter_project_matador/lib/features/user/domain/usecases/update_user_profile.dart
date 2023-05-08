import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class UpdateUserProfile {
  final UserRepository? repository;
  UpdateUserProfile(this.repository);

  Future<Either<Failure, User>> execute({
    required int id,
    String? userName,
    String? email,
    String? fullName,
    String? expertise,
    String? aboutMe,
    String? profilePicture,
  }) async {
    final userToUpdate = User(
      id: id,
      userName: userName ?? '',
      email: email ?? '',
      fullName: fullName ?? '',
      expertise: expertise,
      aboutMe: aboutMe,
      profilePicture: profilePicture,
    );
    return await repository!.updateUserProfile(userToUpdate);
  }
}
