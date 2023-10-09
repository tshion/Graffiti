package io.github.tshion.graffiti

import android.os.Build
import android.os.StrictMode

/**
 * Debug ビルド時に適用するApplication クラス
 */
class DebugApplication : MainApplication() {

    override fun onCreate() {
        // region: StrictMode の設定
        StrictMode.VmPolicy.Builder()
            // .detectActivityLeaks() // LeakCanary で代用
            // .detectCleartextNetwork() // Android OS 9 以降はそもそも明示的な設定が必要なため、省略
            .detectContentUriWithoutPermission()
            .detectCredentialProtectedWhileLocked()
            .detectFileUriExposure()
            .detectImplicitDirectBoot()
            .apply {
                if (Build.VERSION_CODES.S <= Build.VERSION.SDK_INT) {
                    detectIncorrectContextUse()
                }
            }
            .detectLeakedClosableObjects()
            .detectLeakedRegistrationObjects()
            .detectLeakedSqlLiteObjects()
            .detectNonSdkApiUsage()
            .apply {
                if (Build.VERSION_CODES.S <= Build.VERSION.SDK_INT) {
                    detectUnsafeIntentLaunch()
                }
            }
            .detectUntaggedSockets()
            .penaltyDeath()
            .build()
            .also { StrictMode.setVmPolicy(it) }
        // endregion

        super.onCreate()
    }
}
