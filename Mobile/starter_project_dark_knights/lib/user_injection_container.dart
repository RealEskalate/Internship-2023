import 'package:dark_knights/core/network/network_info.dart';
import 'package:dark_knights/features/Authentication/domain/repositories/authentication_repository.dart';
import 'package:dark_knights/features/Authentication/domain/usecases/loginUsecase.dart';
import 'package:dark_knights/features/Authentication/domain/usecases/signupUsecase.dart';
import 'package:dark_knights/features/Authentication/presentation/bloc/authentication_bloc.dart';
import 'package:dark_knights/features/article/data/datasources/article_local_data_source.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_local_data_source.dart';
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
import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;

final sl = GetIt.instance;

Future<void> userDependencyInit() async {
  //! Features - Auth
  () => UserBloc(
        loginUseCase: sl(),
        signupUseCase: sl(),
      );

  //! usecases
  sl.registerLazySingleton(() => CreateUser(sl()));
  sl.registerLazySingleton(() => DeleteUser(sl()));
  sl.registerLazySingleton(() => EditUserProfile(sl()));
  sl.registerLazySingleton(() => GetAllUsers(sl()));
  sl.registerLazySingleton(() => GetFollower(sl()));
  sl.registerLazySingleton(() => GetFollowing(sl()));
  sl.registerLazySingleton(() => GetNumberOfFollowers(sl()));
  sl.registerLazySingleton(() => GetNumberOfFollowing(sl()));
  sl.registerLazySingleton(() => GetUser(sl()));

  // Repository
  sl.registerLazySingleton<UserRepository>(
    () => UserRepositoryImpl(
      remoteDataSource: sl(),
      localDataSource: sl(),
      networkInfo: sl(),
    ),
  );

  // Data sources
  sl.registerLazySingleton<UserRemoteDataSource>(
    () => UserRemoteDataSourceImpl(client: sl()),
  );

  //! Core
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  //! External
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
