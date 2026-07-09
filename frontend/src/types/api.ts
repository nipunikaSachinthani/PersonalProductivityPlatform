export interface ApiResponse<T = unknown> {
  data: T | null;
  errors: ErrorDetail[];
  meta: unknown | null;
}

export interface ErrorDetail {
  code: string;
  message: string;
  details: unknown | null;
}

export interface HealthStatus {
  status: 'Healthy' | 'Unhealthy';
  timestamp: string;
  database: 'Connected' | 'Disconnected';
}
