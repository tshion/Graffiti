@Suppress("DSL_SCOPE_VIOLATION") // TODO: Remove once KTIJ-19369 is fixed
plugins {
    alias(libs.plugins.androidLibrary)
    alias(libs.plugins.dokka)
    alias(libs.plugins.kotlinAndroid)
    id("maven-publish")
}

android {
    namespace = "io.github.tshion.libdroid"
    compileSdk = 34

    defaultConfig {
        aarMetadata {
            minCompileSdk = 21
        }
        consumerProguardFiles("consumer-rules.pro")
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_1_8
        targetCompatibility = JavaVersion.VERSION_1_8
    }
    kotlinOptions {
        jvmTarget = "1.8"
    }
    publishing {
        singleVariant("release") {
            withJavadocJar()
            withSourcesJar()
        }
    }
}

dependencies {

    implementation(libs.appcompat)
    implementation(libs.core.ktx)
    implementation(libs.material)
}

publishing {
    publications {
        register<MavenPublication>("release") {
            artifactId = "libdroid"
            groupId = "io.github.tshion.graffiti"
            version = "0.0.1"

            afterEvaluate {
                from(components["release"])
            }
        }
        repositories {
            maven {
                name = "GitHubPackages"
                url = uri("https://maven.pkg.github.com/tshion/Graffiti")
                credentials {
                    username = "${(project.findProperty("gpr.user") ?: System.getenv("USERNAME"))}"
                    password = "${project.findProperty("gpr.key") ?: System.getenv("TOKEN")}"
                }
            }
        }
    }
}
