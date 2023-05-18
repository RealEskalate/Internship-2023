import 'package:bloc/bloc.dart';
import 'package:dartsmiths/features/profile/domain/usecases/get_user_profile.dart';
import 'package:equatable/equatable.dart';

import '../../domain/entities/user_profile.dart';

part 'profile_event.dart';
part 'profile_state.dart';

class ProfileBloc extends Bloc<ProfileEvent, ProfileState> {

  final GetUserProfile getUserProfile;
  ProfileBloc(this.getUserProfile) : super(ProfileInitial()) {
    on<ProfileEvent>((event, emit) {
      emit(ProfileLoading());
    });

    on<GetProfileEvent>((event, emit) async {
      
      try {
        emit(ProfileLoading());
        final userProfile = await getUserProfile(event.id);
        emit(ProfileSuccess(userProfile: userProfile as UserProfile));
        
      } catch (e) {
        emit(ProfileFailure(error: e as Error));
      }

    });
  }
}
