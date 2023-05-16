import 'package:connectivity/connectivity.dart';

abstract class NetworkInfo {
  Future<bool> isNetworkAvailable() async {
    final connectivityResult = await Connectivity().checkConnectivity();
    return connectivityResult != ConnectivityResult.none;
  }
}
