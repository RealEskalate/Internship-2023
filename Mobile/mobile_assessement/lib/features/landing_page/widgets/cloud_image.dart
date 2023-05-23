
import 'package:flutter/material.dart';

class CloudImage extends StatelessWidget {
  const CloudImage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return const Image(image: AssetImage("assets/images/cloud_image.png"));
  }
}
