import 'package:bloc/bloc.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/edit_user_profile.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import '../../domain/usecases/get_user.dart';
part 'user_profile_state.dart';
part 'user_profile_event.dart';

class UserProfileBloc extends Bloc<ProfileEvent, userProfileState> {
  final GetUser getUser;
  final EditUserProfile editUser;

  UserProfileBloc({
    required this.getUser,
    required this.editUser,
  }) : super(ProfileInitial()) {
    on<UpdateProfileEvent>(_updateProfile);
    on<LoadUserEvent>(_loadUser);
  }

  void _updateProfile(
      UpdateProfileEvent event, Emitter<userProfileState> emit) async {
    emit(ProfileSaving());
    final result = await editUser(event.user);
    emit(_updateSuccessOrFailure(result));
  }

  void _loadUser(LoadUserEvent event, Emitter<userProfileState> emit) async {
    emit(ProfileLoading());
    final result = await getUser(event.userId);
    emit(_loadingSuccessOrFailure(result));
  }

  userProfileState _updateSuccessOrFailure(Either<Failure, UserEntity> data) {
    return data.fold((failure) => ProfileFailure(error: failure),
        (success) => ProfileSaved());
  }

  userProfileState _loadingSuccessOrFailure(Either<Failure, UserEntity> data) {
    return data.fold((failure) => ProfileFailure(error: failure),
        (success) => ProfileLoaded(user: success));
  }
}
