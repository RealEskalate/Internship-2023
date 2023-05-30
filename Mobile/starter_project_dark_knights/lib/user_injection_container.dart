import 'package:dark_knights/features/user_profile/data/datasources/user_remote_data_source.dart';
import 'package:dark_knights/features/user_profile/data/repositories/user_repository_impl.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/create_user.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/delete_user.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/edit_user_profile.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_all_users.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_followers.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_following.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_number_of_followers.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_number_of_following.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:dark_knights/features/user_profile/presentation/bloc/user_profile_bloc.dart';
import 'package:get_it/get_it.dart';

final sl = GetIt.instance;
Future<void> userInjectionInit() async {
//Bloc
  sl.registerFactory(() => UserProfileBloc(getUser: sl(), editUser: sl()));
// usecases
  sl.registerLazySingleton(() => GetUser(sl()));
  sl.registerLazySingleton(() => EditUserProfile(sl()));
  sl.registerLazySingleton(() => GetNumberOfFollowers(sl()));
  sl.registerLazySingleton(() => GetNumberOfFollowing(sl()));
  sl.registerLazySingleton(() => GetFollowing(sl()));
  sl.registerLazySingleton(() => GetFollower(sl()));
  sl.registerLazySingleton(() => CreateUser(sl()));
  sl.registerLazySingleton(() => DeleteUser(sl()));
  sl.registerLazySingleton(() => GetAllUsers(sl()));
//Repository

  sl.registerLazySingleton<UserRepository>(() => UserRepositoryImpl(
        remoteDataSource: sl(),
      ));
//Data sources
  sl.registerLazySingleton<UserRemoteDataSource>(
      () => UserRemoteDataSourceImpl(client: sl()));
}
